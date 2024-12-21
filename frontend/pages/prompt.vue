<template>
   <div class="flex flex-col justify-end min-h-screen px-4 pb-8">
     
     <div class="text-center mb-6">
       <h1 class="text-4xl font-bold mb-2 text-[#382E2E] dark:text-white">Promptus</h1>
       <p class="text-lg text-[#382E2E] dark:text-white">How can I help you today?</p>
     </div>
 
     
     <div class="w-full flex justify-center mb-8">
       <div
         class="bg-[#F4F4F4] dark:bg-[#0a072b] text-[#382E2E] dark:text-white p-4 border-2 border-[#C0C0C0] rounded-lg w-[1154px] h-[250px] dark:border-[#0a072b] relative"
       >
         
         <p v-if="response === ''" class="text-[#B0A8A1] dark:text-[#787878]">
           Send your message to Promptus
         </p>
         
         <p v-else class="text-[#382E2E] dark:text-white">
           {{ response }}
         </p>
 
         
         <div class="absolute bottom-4 right-4 flex space-x-4">
           <button
             @click="handleAcceptResponse"
             class="p-2 bg-green-500 text-white rounded-full hover:bg-green-600"
             aria-label="Aceptar"
           >
             <svg xmlns="http://www.w3.org/2000/svg" class="h-6 w-6" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2">
               <path stroke-linecap="round" stroke-linejoin="round" d="M5 13l4 4L19 7" />
             </svg>
           </button>
           <button
             @click="handleRejectResponse"
             class="p-2 bg-red-500 text-white rounded-full hover:bg-red-600"
             aria-label="Rechazar"
           >
             <svg xmlns="http://www.w3.org/2000/svg" class="h-6 w-6" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2">
               <path stroke-linecap="round" stroke-linejoin="round" d="M6 18L18 6M6 6l12 12" />
             </svg>
           </button>
         </div>
       </div>
     </div>
 
     
     <div class="w-full flex justify-center mb-4 relative">
       <textarea
         v-model="userInput"
         class="bg-[#F4F4F4] dark:bg-[#0a072b] text-[#382E2E] dark:text-white placeholder-[#B0A8A1] p-4 border-2 border-[#C0C0C0] rounded-lg focus:outline-none w-[1154px] h-[250px] resize-none dark:border-[#0a072b]"
         :placeholder="placeholderText"
         maxlength="200"
       ></textarea>
      
       <div class="absolute bottom-4 right-[2.5rem]">
         <button
           @click="submitPrompt"
           class="p-2 bg-blue-500 text-white rounded-full hover:bg-blue-600"
           aria-label="Enviar"
         >
           <svg xmlns="http://www.w3.org/2000/svg" class="h-6 w-6" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2">
             <path stroke-linecap="round" stroke-linejoin="round" d="M14.828 9.172l-4-4m0 0l-4 4m4-4v12" />
           </svg>
         </button>
       </div>
     </div>
   </div>
 </template>
 
 <script setup lang="ts">
 import { ref } from "vue";
 
 
 const response = ref("");
 const userInput = ref("");
 const placeholderText = ref("How can I help you improve your prompts?");
 let lastPrompt = "";
 
 
 const fetchResponseFromBackend = async (prompt: string): Promise<string> => {
   try {
     await new Promise((resolve) => setTimeout(resolve, 1000));
     return `Respuesta generada para: "${prompt}"`;
   } catch (error) {
     console.error("Error al obtener la respuesta:", error);
     return "Error al obtener la respuesta.";
   }
 };
 
 
 const submitPrompt = async () => {
   if (userInput.value.trim() === "") return;
   lastPrompt = userInput.value;
   response.value = "Generando respuesta...";
   const newResponse = await fetchResponseFromBackend(userInput.value);
   response.value = newResponse;
   userInput.value = "";
   placeholderText.value = "How can I help you improve your prompts?";
 };
 
 
 const handleAcceptResponse = () => {
   if (lastPrompt === "") {
     placeholderText.value = "Please write your prompt here and Promptus will improve it";
     return;
   }
 };
 
 
 const handleRejectResponse = async () => {
   if (lastPrompt === "") {
     placeholderText.value = "Please write your prompt here and Promptus will improve it";
     return;
   }
   response.value = "Generando una nueva respuesta...";
   const newResponse = await fetchResponseFromBackend("Nueva sugerencia por rechazo");
   response.value = newResponse;
 };
 </script>
 
 <style scoped>
 
 textarea {
   padding-right: 6rem;
 }
 div.relative {
   position: relative;
 }
 </style>
 
 