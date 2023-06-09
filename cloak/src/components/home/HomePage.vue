<script setup lang="ts">
import { onMounted, ref } from 'vue'
import { supabase } from '@/lib/supabaseClient'

const movies = ref()
async function getMovies() {
  const { data } = await supabase
    .from('Movies')
    .select()
  movies.value = data
}
onMounted(() => {
  getMovies()
})
function getImageSize(Items: string[], size: string) {
  return Items.filter(item => item == size)
}
function returnJoinedString(Item: [], delimitter: string) {
return Item.join(delimitter)
}
</script>

<template>
  <div
    class="bg-oxrk-black w-11/12 min-h-screen text-oxrk-grey flex flex-col font-semibold text-3xl justify-center justify-items-center items-center">
    <div v-for="movie in movies" :key="movie.id" class="grid grid-cols-2 grid-rows-1">
      <div>
        <span>
          <img :src="movie.secure_base_image_URL + getImageSize(movie.poster_sizes, 'w342') + movie.poster_path" />
        </span> </div>
       <div class="grid grid-cols-1 grid-rows-9">
        <span>yahan peshab karna mana hai</span>
        <span>{{ movie.title }}</span>
        <span>yahan peshab karna mana hai</span>
        <span><ul><li>{{ movie.original_language_english_name }}</li>
        <li>{{ movie.release_date }}</li>
        <li>{{ returnJoinedString(movie.genre_names, ",") }}</li>
        </ul></span>
        <span>yahan peshab karna mana hai</span>
        <span>yahan peshab karna mana hai</span>
        <span>yahan peshab karna mana hai</span>
        <span>yahan peshab karna mana hai</span>
        <span>yahan peshab karna mana hai</span>
      </div>
    </div>
  </div>
</template>

<style scoped></style>
