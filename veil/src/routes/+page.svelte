<script>
  export let data;
  let year = function dateParser(date) {
    const parsedDate = new Date(date);
    return parsedDate.getFullYear();
  };
</script>

<div class="overflow-auto bg-slate-900 pt-16 px-4 text-zinc-50">
  <ul class="grid list-none grid-cols-1 md:grid-cols-4 justify-items-center	gap-4 font-display">
    {#each data.movies as movie}
      <li class="max-w-80">
        <img
          src="{movie.secure_base_image_URL}/w342/{movie.poster_path}"
          alt="official movie poster of {movie.title}"
          class="mb-2"
        />
        <span class="text-2xl font-semibold">{movie.title}</span>
        <div class="my-2 flex justify-between">
          <span class="mr-3">{year(movie.release_date)}</span>
          <span class="mr-3">{movie.runtime} mins</span>
          <span class="mr-3">{movie.original_language_english_name}</span>
        </div>
        <div class="mb-4 mt-2 font-light">{movie.overview}</div>
      </li>
    {/each}
  </ul>
</div>
