import plugin from "tailwindcss/plugin";


/** @type {import('tailwindcss').Config} */
export default {
  darkMode: 'class',
  important: true,  
  content: [
    './components/**/*.vue',
    './layouts/**/*.vue',
    './pages/**/*.vue',
  ],
  theme: {
    extend: {
      colors: {
        primary: {
          DEFAULT: '#FFFFFF', 
          dark: '#001845', 
        },
        secondary: {
          DEFAULT: '#FFFFFF', 
          dark: '#001845', 
        },
        accent: {
          DEFAULT: '#001845', 
          dark: '#001845', 
        },
        textPrimary: {
          DEFAULT: '#FFFFFF', 
          dark: '#D1D5DB',
        },
        textSecondary: {
          DEFAULT: '#A3A3A3', 
          dark: '#6B7280', 
        },
      },
    },
  },
  plugins: [
    require('tailwindcss-primeui'),
    plugin(function ({ matchUtilities, e }) {
      matchUtilities({
        'icon': (value) => ({
          content: `"${value.replace(' ', '_')}"`,
        }),
      });
    }),
  ],
};




