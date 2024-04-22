//import { supabase } from "$lib/supabaseClient";
import { createClient } from "@supabase/supabase-js";
import { env } from "$env/dynamic/private";
const supabaseUrl = env.SUPABASE_URL;
const supabaseKey = env.SUPABASE_ANON_KEY;


export async function load() {
  const supabase = createClient(supabaseUrl, supabaseKey); 
  const { data } = await supabase.from("Movies").select();
  return {
    movies: data ?? [],
  };
}
