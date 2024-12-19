<script setup lang="ts">

</script>

<template>
   <div>
      <div class="text-green-700">Este es mi index</div>

      <NuxtLink to="prompt">
         Empezar
      </NuxtLink>

      <NuxtLink to="historico/settings">
         Historico
      </NuxtLink>

      <div class="flex flex-col gap-1">
         <PrimeInputText name="username" type="text" placeholder="Username" />
         <PrimeMessage severity="error" size="small" variant="simple">ASDD</PrimeMessage>
      </div>
   </div>
</template>

<style scoped>

</style>