/** @type {import('tailwindcss').Config} */
export default {
  content: [
    "./index.html",
    "./src/**/*.{vue,js,ts,jsx,tsx}",
  ],
  theme: {
    extend: {
      colors: {
        'oxrk-black': '#110808',
        'oxrk-grey': '#505050',
        'oxrk-white': '#D9D9D9',
      },
      fontFamily: {
        'oxrk-title': ['Open Sans', 'sans-serif']
      }
    },
  },
  plugins: [],
}