Vue.component('charttable', {
    props: ['proplabels'],
    data() {
        return {
            disabled: true
        }
    },
    methods: {
        deleteEvent: function (index) {
            this.proplabels.splice(index, 1);
        }
    },
    template:
        `
<div id="chart_table">
        <div class="top_titles">
            <div class="small-12 medium-1 column"> id </div>
            <div class="small-12 medium-6 column"> Issue </div>
            <div class="small-12 medium-1 column"> Severity </div>
            <div class="small-12 medium-1 column"> Status </div>
            <div class="small-12 medium-2 column"> Asignee </div>
            <div class="small-12 medium-1 column">
                <i class="fa fa-trash" aria-hidden="true"></i>
            </div>
        </div>
    <div v-for="(val, index)al in proplabels" class="row table_cell">
        <div class="small-12 medium-1 column">
            <input type="text" v-model="val.id" disabled @change="app.issueModified($event,index)"></input>
        </div>
        <div class="small-12 medium-6 column single-cel">
            <input type="text" v-model="val.title" v-bind:disabled="disabled" v-on:keyup.stop.prevent="app.issueModified($event,index)" @change="app.issueModified($event,index)"> </input>
        </div>
        <div class="small-12 medium-1 column single-cel">
            <select class="form-control" v-model="val.severity" @change="app.issueModified($event,index)">
                <option v-for="option in app.severityOptions" v-bind:value="option.id" >{{ option.title }}</option>
            </select>
        </div>
        <div class="small-12 medium-1 column single-cel">
            <select class="form-control" v-model="val.status" @change="app.issueModified($event,index)">
                <option v-for="option in app.statusOptions" v-bind:value="option.id" >{{ option.title }}</option>
            </select>
        </div>
        <div class="small-12 medium-2 column single-cel">
            <select class="form-control" v-model="val.asignee" @change="app.issueModified($event,index)">
                <option></option>
                <option v-for="option in app.asigneeOptions" v-bind:value="option.id" >{{ option.name }}</option>
            </select>
        </div>
        <div class="small-12 medium-1 column edit_panel">
            <button @click="app.deleteEvent($event,index)">
                <i class="fa fa-times" aria-hidden="true"></i>
            </button>
<span class="edit_mode" @click="disabled = !disabled">
                <i class="fa fa-pencil-square-o" aria-hidden="true"></i>
            </span>
        </div>
    </div> <!-- .table_cell -->

  <div class="form-row">
    <div class="form-group col-md-6">
      <label for="inputCity">City</label>
      <input type="text" class="form-control" id="inputCity">
    </div>
    <div class="form-group col-md-4">
      <label for="inputState">State</label>
      <select id="inputState" class="form-control">
        <option selected>Choose...</option>
        <option>...</option>
      </select>
    </div>
    <div class="form-group col-md-2">
      <label for="inputZip">Zip</label>
      <input type="text" class="form-control" id="inputZip">
    </div>
  </div>


</div>

`
})


const app = new Vue({
    el: '#chartpanel',
    data() {
        return {
            value: '',
            label: '',
            icon: '',
            labels: [{ id: 0, percentual: 87, title: 'Mandorle', icon: 'fa-user-circle-o' }],
            nextBarId: 1,
            responseAvailable: false,
            apiKey: "dummy_key",
            result: "",
            severityOptions: [],
            statusOptions: [],
            asigneeOptions: [],
        }
    },
    computed: {

    },
    created: function () {

    },
    mounted: function () {

        var pStatus = fetchAny("issueStatus");
        var pSeverity = fetchAny("issueSeverity");
        var pAsignee = fetchAny("asignees");



        Promise.all([pStatus, pSeverity, pAsignee]).then(values => {
            localStorage.setItem('issueStatus', JSON.stringify(values[0]));
            this.statusOptions = values[0];

            localStorage.setItem('issueSeverity', JSON.stringify(values[1]));
            this.severityOptions = values[1];

            localStorage.setItem('issueAsignee', JSON.stringify(values[2]));
            this.asigneeOptions = values[2];

            this.fetchIssues();

        }, reason => {
            console.log(reason)
        });


    },
    methods: {
        addRow: function (event) {
            lastId = this.labels.length;
            var newRow = {
                title: this.label,
                status: 0,
                severity: 0
            };

            doPost('Issues', newRow).then(response => {
                var newIssue = response;
                this.labels.push(newIssue);
            });
            
        },
        fetchIssues: function () {
            this.responseAvailable = false;

            fetch("/api/issues", {
                "method": "GET",
                "headers": {
                    "Cache-Control": "no-cache",
                    "x-rapidapi-key": this.apiKey
                }
            })
                .then(response => {
                    if (response.ok) {
                        return response.json()
                    } else {
                        alert("Server error " + response.status + " : " + response.statusText);
                    }
                })
                .then(response => {
                    console.log("fin fetchIssues");
                    response.forEach(item => {
                        console.log(item.statusOptions);
                    });
                    this.labels = (response);
                    this.responseAvailable = true;
                })
                .catch(err => {
                    console.log(err);
                });
        },
        issueModified: function (event,index) {
            doPost("issues", this.labels[index]);
        },
        deleteEvent: function (event, index) {
            console.log("Delete");
            doDelete("issues", this.labels[index].id);
        }
    }
});









function fetchAny (controller) {
    {
        return fetch("/api/" + controller, {
            "method": "GET",
            "headers": {
                "Cache-Control": "no-cache"
            }
        })
            .then(response => {
                if (response.ok) {
                    return response.json()
                } else {
                    console.log("Server error " + response.status + " : " + response.statusText);
                    return Promise.resolve([]);
                }
            })
    }
}

function doPost(controller, obj) {
    const requestOptions = {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(obj)
    };
    return fetch('/api/' + controller, requestOptions)
        .then(response => {
            if (response.ok) {
                return response.json()
            } else {
                console.log("Server error " + response.status + " : " + response.statusText);
                return Promise.resolve([]);
            }
        })
        .catch(error => {
            console.error(error);
            Promise.reject(error);
        });
}

function doDelete(controller, id) {
    const requestOptions = {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json' }
    };
    return fetch('/api/' + controller + "/" + id, requestOptions)
        .then(response => {
            if (response.ok) {
                return response.json()
            } else {
                console.log("Server error " + response.status + " : " + response.statusText);
                return Promise.resolve([]);
            }
        })
        .catch(error => {
            console.error(error);
            Promise.reject(error);
        });
}

function getLsArray(key) {
    return JSON.parse(localStorage.getItem(key) || "[]");
}