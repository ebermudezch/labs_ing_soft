<template>
  <div class = "container mt-5">
    <h1 class= "display-4 text-center">Lista de países </h1>
    <div class="row justify-content-end">
      <div class="col-2">
        <a href="country">
          <button type = "button" class="btn btn-outline-secondary float-right">
            Agregar país
          </button>
        </a>
      </div>
    </div>
    <table
      class="table is-bordered is-striped is-narrow is-hoverable
      is-fullwidth"
    >
      <thead>
        <tr>
          <th>Nombre</th>
          <th>Continente</th>
          <th>Idioma</th>
          <th>Acciones</th>
        </tr>
      </thead>
      <tbody>
        <!--Con este tag estamos diciendo quiero un país y el index de array de
        países que creamos en la función data, usaremos como key el index y dentro de cada
        uno de los <td> podemos acceder al objeto individual y acceder a cada una de sus
        propiedades-->
        <tr v-for="(country, index) of countries" :key="index">
          <td> {{ country.name }} </td>
          <td> {{ country.continent }} </td>
          <td> {{ country.language }} </td>
          <td>
            <button class="btn btn-secondary btn-sm">Editar</button>
            <!-- Con @click, ahora el botón conecta con el método deleteCountry y
             pasa como parametro el índice de la fila -->
            <button class="btn btn-danger btn-sm" @click = "deleteCountry(index)">Eliminar</button>
          </td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
import axios from "axios";
export default {
    name: "CountriesList",
    data() {
        return {
            countries: [
                { name: "Costa Rica", continent: "América", language: "Español" },
                { name: "Japón", continent: "Asia", language: "Japonés" },
                { name: "Corea del Sur", continent: "Asia", language: "Coreano" },
                { name: "Italia", continent: "Europa", language: "Italiano" },
                { name: "Alemania", continent: "Europa", language: "Alemán" },
            ],
        };
    },
    methods: {
        // El método splice elimina n elementos en ese índice
        // (si se usara 2, se elimina el actual y el sig)
        deleteCountry(index) {
            this.countries.splice(index, 1);
        },
        getCountries() {
            axios.get("http://localhost:5221/api/country").then((response) => {
                this.countries = response.data;
            });
        },
    },
    created: function () {
        this.getCountries();
    },
};
</script>

<style lang="scss" scoped></style>
