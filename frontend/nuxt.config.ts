import {certificate} from "./net-https";

// https://nuxt.com/docs/api/configuration/nuxt-config
export default defineNuxtConfig({
    compatibilityDate: '2024-12-17',
    modules: ["@nuxtjs/tailwindcss", '@primevue/nuxt-module'],
    postcss: {
        plugins: {
            'postcss-import': {},
            tailwindcss: {},
            autoprefixer: {},
            ...(process.env.NODE_ENV === 'production' ? {cssnano: {}} : {})
        },
    },
    tailwindcss: {
        cssPath: '~/assets/css/tailwind.css'
    },
    primevue: {
        options: {
            theme: 'none',
            ripple: true,
        },
        components: {
            prefix: 'Prime'
        },
    },
    imports: {
        dirs: [
            'composables/**/*.ts',
        ]
    },

    devtools: {enabled: true},
    devServer: {
        port: 3050,
        https: {
            key: certificate.keyFilePath,
            cert: certificate.certFilePath
        }
    }
})