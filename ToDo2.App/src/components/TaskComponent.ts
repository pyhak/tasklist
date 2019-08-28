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
    public msg: string = '';
    mounted() {
        this.getTasklist();
    }
    updateTask(task: Task) {
        task.Status == true ? false : true;
        axios.put('https://localhost:44388/api/task', { id : task.Id, task : task }).then((response) => {
            this.tasklist = response.data
        })
            .catch((e) => {
                console.error(e)
            })
    }
    getTasklist() {
        axios.get('https://localhost:44388/api/task').then((response) => {
            this.tasklist = response.data
        }).catch((e) => {
            console.error(e)
     });
    //    return this.tasklist
    }
    public addTask(description: string) {

        axios.post('https://localhost:44388/api/task', { id: 0, description: description, Status: false }).then((response) => { this.tasklist = response.data })
            .catch((e) => {
                console.error(e)
            })
    }
    
    
}