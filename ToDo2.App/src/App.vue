<template>
    <div id="app">
        <Home msg="Hello world!" />
    </div>
</template>

<script lang="ts">
    import { Component, Vue } from 'vue-property-decorator';
    import Home from './components/Home.vue';
    import { Inject } from 'inversify-props'
    import ITasklistService from '@/services/ITasklistService'
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
