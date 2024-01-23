/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    "./src/**/*.{html,ts}",
  ],
  theme: {
    extend: {
      colors: {
        "primary-green": "#06D6A0",
        "primary-yellow": "#FA0",
        "primary-blue": "#3C91E6",
        "primary-red": "#EF233C",
        "cyan-green": "#47E5BC",
        "ocean-blue": "#003F88",
        "medium-gray": "#E5E5E5",
        "light-gray": "#EDF2F4",
        "light-blue": "#3AE",
        "light-pink": "#FF3366",
        "dark": "#1A1A1A",
        "dark-gray": "#495057",
        "dark-blue": "#0C1B33",
      },
      backgroundImage: {
        "condominium": "url('src/assets/images/condominium.png')",
        "grid": "url('src/assets/images/grid.png')",
      }
    },
  },
  plugins: [],
}

