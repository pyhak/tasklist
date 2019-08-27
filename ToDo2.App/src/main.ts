import Vue from 'vue';
import App from './App.vue';
import buildDependencyContainer from './app.container'

class AppBootstrap {
    constructor() {
        this.loadDependencyContainer()
        this.loadVueApp()
    }

    private loadDependencyContainer(): void {
        buildDependencyContainer()
    }

    private loadVueApp(): void {
        Vue.config.productionTip = false

        new Vue({
            render: h => h(App)
        }).$mount('#app')
    }
}

// eslint-disable-next-line no-new
new AppBootstrap()