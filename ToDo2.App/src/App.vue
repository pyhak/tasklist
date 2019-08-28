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
