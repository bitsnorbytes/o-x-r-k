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
function dateParser(date: string) {
  const parsedDate = new Date(date)
  return parsedDate.getFullYear()
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
        <span class="font-light">uuntur magni dolores eos qui </span>
        <span class="font-bold text-5xl">{{ movie.title }}</span>
        <span class="font-semibold">  Quis autem vel eum iure reprehenderit</span>
        <span><ul class="list-none flex flex-row justify-items-center justify-between items-center font-light"><li>{{ movie.original_language_english_name }}</li>
        <li>{{ dateParser(movie.release_date) }}</li>
        <li>{{ returnJoinedString(movie.genre_names, " / ") }}</li>
        </ul></span>
        <span class="font-normal">Lorem ipsum dolor sit amet</span>
        <span class="font-normal">4th Novemeber 1920</span>
        <span class="font-normal">Festival de cruzzs</span>
        <span class="font-normal">Excepteur sint occaecat cupidatat non proident</span>
        <span class="font-normal">deserunt mollit anim id est laborum</span>
      </div>
    </div>
  </div>
</template>

<style scoped></style>
