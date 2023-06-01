<script setup lang="ts">
import logoSVG from '@/components/icons/OXRKcloak.vue'
</script>

<template>
     <div class="bg-oxrk-black w-1/12 h-screen">
          <ul class="list-none text-oxrk-grey h-full flex flex-col justify-items-center justify-between items-center">
               <li class="p-7">
                    <span class="hover:text-oxrk-white font-oxrk-title font-bold text-2xl tracking-[.5em] uppercase">oxrk</span>
               </li>
               <li>
                    <span class="p-7"><logoSVG /></span>
               </li>
               <li class="p-7">
                    <ul class="list-none text-oxrk-grey font-oxrk-title font-bold text-xl tracking-wide uppercase">
                         <li class="p-2">
                              <span class="hover:text-oxrk-white">Near You</span>
                         </li>
                         <li class="p-2">
                              <span class="hover:text-oxrk-white">Screenings</span>
                         </li>
                         <li class="p-2">
                              <span class="hover:text-oxrk-white">Settings</span>
                         </li>
                         <li class="p-2">
                              <span class="hover:text-oxrk-white">Help</span>
                         </li>
                         <li class="p-2">
                              <span class="hover:text-oxrk-white">Contribute</span>
                         </li>
                    </ul>
               </li>
          </ul>
     </div>
</template>

<style scoped>
</style>
