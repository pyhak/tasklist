import "reflect-metadata";
import { Component, Vue } from "vue-property-decorator";
import Task from '../models/Task';
import WithRender from '@/components/TaskComponent.html'
import axios from 'axios'
import TaskForm from './TaskForm';

@WithRender
@Component({
    components: {
        'task-form': TaskForm
        },
        
        data() {
            return {
                tasklist: [],
                description: ''
            }
        },
        created() {
            axios.get('https://localhost:44388/api/task').then((response) => {
                this.tasklist = response.data
            })
                .catch((e) => {
                    console.error(e)
                })
        }
})
export default class TaskComponent extends Vue {
    public msg: string = '';
    description: any;
    public updateTask(task: Task) {
        task.Status == true ? false : true;
        axios.put('https://localhost:44388/api/task', { id : task.Id, task : task }).then((response) => {
            
        })
            .catch((e) => {
                console.error(e)
            })
    }
    
}