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
                    100: '#fcfdfa',
                    200: '#f0c748',
                    300: '#1a120f',
                    400: '#5f4f20',
                    500: '#aa0105',
                    600: '#18290f',
                    700: '#feec79',
                    800: '#c79242',
                },
            },
    },
  },
plugins: [
    require('@tailwindcss/forms'),
    require('@tailwindcss/typography'),
],
}