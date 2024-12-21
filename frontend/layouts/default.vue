<template>
   <div :class="darkMode ? 'dark' : ''">
     <div class="min-h-screen bg-secondary text-textPrimary dark:bg-secondary-dark dark:text-textPrimary-dark">
       <header class="flex items-center justify-between p-4 bg-primary dark:bg-primary-dark">
         <div class="flex items-center ml-auto">
           <span class="mr-2">🌞</span>
           <label for="dark-mode-toggle" class="relative inline-block w-12 h-6">
             <input 
               id="dark-mode-toggle" 
               type="checkbox" 
               class="sr-only"
               v-model="darkMode"
             />
             <span class="toggle-background absolute inset-0 bg-gray-400 rounded-full cursor-pointer transition-colors"></span>
             <span 
               class="toggle-dot w-6 h-6 bg-white rounded-full absolute top-0.5 left-0.5 transition-transform transform" 
               :class="{ 'translate-x-6': darkMode }"
             ></span>
           </label>
           <span class="ml-2">🌙</span>
         </div>
       </header>
       <main>
         <slot />
       </main>
     </div>
   </div>
 </template>
 
 <script setup>
 import { ref } from 'vue';
 
 const darkMode = ref(false);
 </script>
 
 <style scoped>
 .toggle-background {
     background-color: #ddd; 
 }
 
 .toggle-dot {
     transition: transform 0.3s ease-in-out;
 }
 
 input:checked + .toggle-background .toggle-dot {
     transform: translateX(24px); 
 }
 </style>
 
 
 
 
 
 


