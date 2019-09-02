<template>
    <div id="app">
        <Home msg="Hello world!" />
    </div>
</template>

<script lang="ts">
    import { Component, Vue } from 'vue-property-decorator';
    import Home from './components/Home.vue';
    import BootstrapVue from 'bootstrap-vue'
    import 'bootstrap/dist/css/bootstrap.css'
    import 'bootstrap-vue/dist/bootstrap-vue.css'
    import { library } from '@fortawesome/fontawesome-svg-core'
    import { faTrashAlt } from '@fortawesome/free-solid-svg-icons'
    import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome'

    library.add(faTrashAlt)

    Vue.component('font-awesome-icon', FontAwesomeIcon)
    Vue.use(BootstrapVue)
    @Component({
        components: {
            Home
        }
    })
    export default class App extends Vue {
        
    }
</script>

<style>
</style>
