<template>
    <div class="home">
        <Tasklist />
    </div>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator';
    import Tasklist from '@/components/TaskComponent.ts';

    @Component({
      components: {
        Tasklist,
      },
    })
export default class Home extends Vue {}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
</style>
