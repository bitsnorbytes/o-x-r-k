import { supabase } from "$lib/server/supabaseClient";

export async function load() {
  const { data } = await supabase.from("Movies").select();
  return {
    movies: data ?? [],
  };
}
