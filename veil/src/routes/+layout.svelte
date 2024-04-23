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
<div
  class="flex h-16 flex-row items-center justify-between bg-slate-950 text-zinc-50"
>
  <h1 class="mx-8 font-display text-4xl font-medium tracking-widest">
    <a href="/">oxrk.</a>
  </h1>
  <nav
    class="mx-8 flex flex-row items-center justify-end font-display-2 text-xl"
  >
    <a class="mx-4" href="/near-you">near you</a>
    <a class="mx-4" href="/screenings">screenings</a>
    <a class="mx-4" href="/search">search</a>
    <a class="mx-4" href="/login">login / sign-up</a>
  </nav>
</div>
<slot />
