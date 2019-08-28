import { Component, Vue } from 'vue-property-decorator';
import WithRender from './Task-form.html';
import axios from 'axios'

@WithRender
    @Component
        ({
          
        })
export default class TaskForm extends Vue {
    public description: string='';
    
    public emitTask(): void {

        this.$emit('added', this.description);

        this.description = '';

    }
}