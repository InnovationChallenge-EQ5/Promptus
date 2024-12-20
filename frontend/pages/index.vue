<script setup lang="ts">
</script>

<template>
   <div class="flex flex-col items-center justify-center min-h-screen bg-gradient-animated text-white">
      <h1 class="text-4xl font-bold mb-4">Promptus</h1>
      <div class="text-center text-lg mb-6">
         Perfecciona tus prompts, potencia tu IA
      </div>

      <NuxtLink to="prompt">
         <button class="px-6 py-2 text-lg font-semibold bg-white text-[#382E2E] rounded-full">
            Comenzar
         </button>
      </NuxtLink>
   </div>
</template>

<style scoped>
/* Animación de gradiente en movimiento */
@keyframes gradientMove {
  0% {
    background-position: 0% 50%;
  }
  50% {
    background-position: 100% 50%;
  }
  100% {
    background-position: 0% 50%;
  }
}

.bg-gradient-animated {
  background: linear-gradient(to bottom, #001845 0%, #0F2E68 50%, #001845 100%);
  background-size: 200% 200%;
  animation: gradientMove 5s ease infinite;
}
</style>

