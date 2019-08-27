import { Component, Vue } from 'vue-property-decorator';
import WithRender from './Task-form.html';
import axios from 'axios'

@WithRender
    @Component
        ({
            data() {
                return {
                    description: ''
                }
            }
        })
export default class TaskForm extends Vue {
    description: any;
    addTask() {
        
        axios.post('https://localhost:44388/api/task', { id: 0, description: this.description, Status: false }).then((response) => { this.tasklist = response.data })
            .catch((e) => {
                console.error(e)
            })
    }
}