<template>
  <div class="home flex-grow-1 d-flex flex-column align-items-center justify-content-center">
    <!-- <div class="home-card p-5 bg-white rounded elevation-3">
      <img
        src="https://bcw.blob.core.windows.net/public/img/8600856373152463"
        alt="CodeWorks Logo"
        class="rounded-circle"
      >
      <h1 class="my-5 bg-dark text-white p-3 rounded text-center">
        Vue 3 Starter
      </h1>
    </div> -->
    <div v-if="cars">
      <div v-for="c in cars" :car="c">
        <div class="home-card">
          <div class="row">
            <div class="col-4">
              <img :src="car.imgUrl" :alt="car.make" class="img-fluid">
            </div>
            <div class="col-8">
              <h1 style="color: rgb(50,50,50);">{{car.year}} {{car.make}} {{car.model}}</h1>
                <h4 style="color: rgb(5,255,5);">${{car.price}}</h4>
                <p style="color: rgb(50,50,50);">{{car.description}}</p>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { onMounted } from 'vue';
import Pop from '../utils/Pop.js';
import { carsService } from '../services/CarsService.js';
import { computed } from '@vue/reactivity';
import { AppState } from '../AppState.js';

export default {
  setup() {
    async function getCars() {
      try {
        await carsService.getCars()
      } catch (error) {
        Pop.error(error, '[Getting Cars]')
      }
    }
    onMounted(()=>{
      getCars()
    })
    return {
      cars: computed(()=> AppState.cars)
    }
  }
}
</script>

<style scoped lang="scss">
.home {
  display: grid;
  height: 80vh;
  place-content: center;
  text-align: center;
  user-select: none;

  .home-card {
    width: 50vw;

    >img {
      height: 200px;
      max-width: 200px;
      width: 100%;
      object-fit: contain;
      object-position: center;
    }
  }
}
</style>
