import { env } from "$env/dynamic/private";

export const supabaseUrl = env.SUPABASE_URL;
export const supabaseKey = env.SUPABASE_ANON_KEY;
