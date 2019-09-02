import { Component, Vue } from 'vue-property-decorator';
import WithRender from './Task-form.html';

@WithRender
    @Component
        ({
          
        })
export default class TaskForm extends Vue {
    public description: string='';
    public errors: string[] = [];
    

    public emitTask(): void {
        if (this.description) {
            this.errors = [];
            this.$emit('added', this.description);
            this.description = '';
        }
        else {
            if (!this.description) {
                this.errors.push("Task description.");
            }
        }

    }
}