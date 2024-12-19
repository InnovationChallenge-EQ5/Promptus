import plugin from "tailwindcss/plugin";

/** @type {import('tailwindcss').Config} */
export default {
  darkMode: 'class',
  content: [
    './components/**/*.vue',
    './layouts/**/*.vue',
    './pages/**/*.vue',
  ],
  theme: {
    extend: {},
  },
  plugins: [require('tailwindcss-primeui'), plugin(function ({matchUtilities, e}) {
    matchUtilities({
          'icon': (value) => ({
            content: `"${value.replace(' ', '_')}"`,
          }),
        }
    )
  })]
}

