<template>
  <div class="d-flex justify-content-center align-items-center vh-100">
    <div class="card p-4 shadow" style="max-width: 400px; width: 100%">
      <h3 class="text-center">Formulario de creación de países</h3>
      <form @submit.prevent="saveCountry">
        <div class="form-group">
          <label for="nombre">Nombre:</label>
            <input
            v-model="formData.Name"
            type="text"
            id="name"
            class="form-control"
            required
          />
        </div>
      <div class="form-group">
        <label for="continente">Continente:</label>
        <select
          v-model="formData.Continent"
          id="continente"
          required
          class="form-control"
        >
          <option value="" disabled>Seleccione un continente</option>
          <option>África</option>
          <option>Asia</option>
          <option>Europa</option>
          <option>América</option>
          <option>Oceanía</option>
          <option>Antártida</option>
        </select>
      </div>
      <div class="form-group">
        <label for="idioma">Idioma:</label>
          <input
          v-model="formData.Language"
          type="text"
          id="idioma"
          class="form-control"
          required
        />
      </div>
      <div>
        <button type="submit" class="btn btn-success btn-block">
          Guardar
        </button>
      </div>
    </form>
  </div>
 </div>
</template>

<script>
import axios from "axios";
export default{
  data() {
    return {
      formData: { Name: "", Continent: "", Language: " "},
    };
  },
  methods: {
    saveCountry() {
      console.log("Datos a guardar:", this.formData);
      axios
        .post("http://localhost:5221/api/country", {
          // Creando un objeto de tipo json -> se envia al back end 
          // donde está pasando todos los datos esperando por este 
          Name: this.formData.Name,
          Continent: this.formData.Continent,
          Language: this.formData.Language,
        })
        //Una vez completado el post, que sigue (en este caso:
        // imprime en consola la respuesta y redirecciona al home page)
        .then(function (response) {
          console.log(response);
          window.location.href = "/";
        })
        .catch(function (error) {
          console.log(error);
        });
    },
  },
};
</script>

<style></style>
