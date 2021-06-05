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
            <input type="text" v-model="val.id" disabled></input>
        </div>
        <div class="small-12 medium-6 column single-cel">
            <input type="text" v-model="val.title" v-bind:disabled="disabled"> </input>
        </div>
        <div class="small-12 medium-1 column single-cel">
            <select class="form-control">
                <option v-for="option in val.severityOptions" v-bind:value="option.id" >{{ option.title }}</option>
            </select>
        </div>
        <div class="small-12 medium-1 column single-cel">
            <select class="form-control" v-model="val.status">
                <option v-for="option in val.statusOptions" v-bind:value="option.id" >{{ option.title }}</option>
            </select>
        </div>
        <div class="small-12 medium-2 column single-cel">
            <select class="form-control" v-model="val.asignee">
                <option></option>
                <option v-for="option in val.asigneeOptions" v-bind:value="option.id" >{{ option.name }}</option>
            </select>
        </div>
        <div class="small-12 medium-1 column edit_panel">
            <button @click="deleteEvent(index)">
                <i class="fa fa-times" aria-hidden="true"></i>
            </button>
<span class="edit_mode" @click="disabled = !disabled">
                <i class="fa fa-pencil-square-o" aria-hidden="true"></i>
            </span>
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
                id: this.nextBarId++,
                percentual: this.value,
                label: this.label,
                icon: this.icon
            };
            this.labels.push(newRow);
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
                        item.asigneeOptions = this.asigneeOptions;
                        item.statusOptions = this.statusOptions;
                        item.severityOptions = this.severityOptions;
                        console.log(item.statusOptions);
                    });
                    this.labels = (response);
                    this.responseAvailable = true;
                })
                .catch(err => {
                    console.log(err);
                });
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

function getLsArray(key) {
    return JSON.parse(localStorage.getItem(key) || "[]");
}