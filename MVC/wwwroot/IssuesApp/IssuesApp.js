Vue.component('issuestable', {
    props: ['propissues'],
    data() {
        return {
            disabled: true
        }
    },
    methods: {
        deleteEvent: function (index) {
            this.$emit('delete-issue-index', index);
        },
        updateEvent: function (index) {
            this.$emit('update-issue-index', index);
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
                &nbsp;
            </div>
        </div>
    <div v-for="(val, index)al in propissues" class="row table_cell">
        <div class="small-12 medium-1 column">
            <input type="text" v-model="val.id" disabled @change="updateEvent(index)"></input>
        </div>
        <div class="small-12 medium-6 column single-cel">
            <input type="text" v-model="val.title" v-on:keyup.stop.prevent="updateEvent(index)" @change="updateEvent(index)"> </input>
        </div>
        <div class="small-12 medium-1 column single-cel">
            <select v-model="val.severity" @change="updateEvent(index)">
                <option v-for="option in app.severityOptions" v-bind:value="option.id" >{{ option.title }}</option>
            </select>
        </div>
        <div class="small-12 medium-1 column single-cel">
            <select v-model="val.status" @change="updateEvent(index)">
                <option v-for="option in app.statusOptions" v-bind:value="option.id" >{{ option.title }}</option>
            </select>
        </div>
        <div class="small-12 medium-2 column single-cel">
            <select v-model="val.asignee" @change="updateEvent(index)">
                <option></option>
                <option v-for="option in app.asigneeOptions" v-bind:value="option.id" >{{ option.name }}</option>
            </select>
        </div>
        <div class="small-12 medium-1 column edit_panel">
            <button @click="deleteEvent(index)">
                <i class="fa fa-times" aria-hidden="true"></i>
            </button>
<span class="edit_mode" @click="alert('popup para introducir descripción')">
                <i class="fa fa-pencil-square-o" aria-hidden="true"></i>
            </span>
        </div>
    </div> <!-- .table_cell -->
</div>

`
})


const app = new Vue({
    el: '#chartpanel',
    data() {
        return {
            newIssueLabel: '',
            issues: [],
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

            this.$refs.newIssueLabel.focus();

        }, reason => {
            console.log(reason)
        });


    },
    methods: {
        addRow: function (event) {
            lastId = this.issues.length;
            var newRow = {
                title: this.newIssueLabel,
                status: 0,
                severity: 0
            };

            doPost('Issues', newRow).then(response => {
                var newIssue = response;
                this.issues.push(newIssue);
                this.newIssueLabel = "";
            });
            this.$refs.newIssueLabel.focus();
            
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
                    this.issues = (response);
                    this.responseAvailable = true;
                })
                .catch(err => {
                    console.log(err);
                });
        },
        issueModified: function (index) {
            doPost("issues", this.issues[index]);
        },
        deleteEvent: function (index) {
            doDelete("issues", this.issues[index].id);
            this.issues.splice(index, 1);
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
                    return Promise.reject([]);
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
                return Promise.resolve([]);
            } else {
                console.log("Server error " + response.status + " : " + response.statusText);
                return Promise.reject([]);
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