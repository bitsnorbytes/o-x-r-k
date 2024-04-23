import { createClient } from "@supabase/supabase-js";
import { supabaseUrl,supabaseKey } from "$lib/server/secrets";

export async function load() {
  const supabase = createClient(supabaseUrl, supabaseKey);
  const { data } = await supabase.from("Movies").select();
  return {
    movies: data ?? [],
  };
}
