/** @type {import('tailwindcss').Config} */
module.exports = {
    content: [
        "./Pages/**/*.{razor,html,cshtml}"
    ],
    theme: {
        extend: {
            fontFamily: {
                'gy-body': ["Open Sans", "sans-serif"]
            },
            colors: {
                blute: {
                    100: '#348888',
                    200: '#22BABB',
                    300: '#9EF8EE',
                    400: '#FA7F08',
                    500: '#F24405'
}
          },
    },
  },
plugins: [
    require('@tailwindcss/forms'),
    require('@tailwindcss/typography'),
],
}