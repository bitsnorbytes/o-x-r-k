<script setup lang="ts">
import { RouterLink, RouterView } from 'vue-router'
import LandingPage from './components/LandingPage.vue'
</script>

<template>
  <header>
     <div>
      <LandingPage msg="You did it!" />

      <!-- <nav>
        <RouterLink to="/">Home</RouterLink>
        <RouterLink to="/about">About</RouterLink>
      </nav> -->
    </div>
  </header>

  <RouterView />
</template>

<style scoped>
</style>
