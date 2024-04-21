/** @type {import('tailwindcss').Config} */
export default {
  content: ["./src/**/*.{html,js,svelte,ts}"],
  theme: {
    extend: {},
    fontFamily: {
      display: ['"Noto Serif"', "serif"],
      "display-2": ['"Josefin Sans"', "sans-serif"],
      body: ['"IBM Plex Sans"', "sans-serif"],
    },
  },
  plugins: [],
};
