import "reflect-metadata";
import { Component, Vue } from "vue-property-decorator";
import Task from '../models/Task';
import WithRender from '@/components/TaskComponent.html'
import axios from 'axios'
import TaskForm from './TaskForm';

@WithRender
@Component({
    components: {
        'task-form': TaskForm,
        
        }
})
export default class TaskComponent extends Vue {
    tasklist: Task[] = [];
    description: '' | undefined;
    URL: string = 'http://localhost/Tasklist.Api/api/task';
    public msg: string = '';
    mounted() {
        this.getTasklist();
    }
    updateTask(task: Task) {
        task.Status = task.Status == true ? false : true;
        axios.post(this.URL, task).then((response) => {
            this.tasklist = this.mapTask(response.data)
        })
            .catch((e) => {
                console.error(e)
            })
    }
    getTasklist() {
        axios.get(this.URL).then((response) => {
            this.tasklist = this.mapTask(response.data)
        }).catch((e) => {
            console.error(e)
            });
    }
    deleteTask(task: Task): void {
        axios.delete(this.URL).then((response) => {
            this.tasklist = this.mapTask(response.data)
        }).catch((e) => {
            console.error(e)
        });
    }
    public addTask(description: string) {

        axios.post(this.URL, { id: 0, description: description, Status: false }).then((response) => { this.tasklist = this.mapTask(response.data) })
            .catch((e) => {
                console.error(e)
            })
    }
    private mapTask(tasks : any[]) {
        var mappedTasks: Task[] = [];
        tasks.forEach(function (task) {
            var t = {
                Id: task.id,
                Description: task.description,
                Status: task.status
            };
            mappedTasks.push(t);
        });
        return mappedTasks;
    }
    
}