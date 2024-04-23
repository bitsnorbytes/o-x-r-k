<script>
  import "../style/app.css";
</script>

<svelte:head>
  <link rel="preconnect" href="https://fonts.googleapis.com" />
  <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin />
  <link
    href="https://fonts.googleapis.com/css2?family=IBM+Plex+Sans:ital,wght@0,100;0,200;0,300;0,400;0,500;0,600;0,700;1,100;1,200;1,300;1,400;1,500;1,600;1,700&family=Josefin+Sans:ital,wght@0,100..700;1,100..700&family=Noto+Serif:ital,wght@0,427;1,427&display=swap"
    rel="stylesheet"
  />
</svelte:head>
<div class="relative w-full text-zinc-50">
<div class="fixed flex items-center top-0 w-full md:w-3/12 h-16 bg-slate-950">
  <span class="mx-8 font-display text-4xl font-medium tracking-widest  ">
    <a href="/">oxrk.</a>
  </span>
</div>
<div class="fixed flex items-center justify-center md:justify-end bottom-0 md:top-0 md:right-0 w-full md:w-9/12 h-16 bg-slate-950">
  <nav
    class="mx-8 flex  items-center justify-center font-display-2 text-xl"
  >
    <a class="mx-4" href="/screenings">screenings</a>
    <a class="mx-4" href="/search">search</a>
    <a class="mx-4" href="/login">login</a>
  </nav>
</div>
</div>
<slot />
