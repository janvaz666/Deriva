<template>
  <div class="row">
    <div class="col-md-12">
      <card>
        <template slot="header">
          <h2 class="text-center">Comunalia: Iniciativa Autocuidados y Salud Mental de los Equipos de las Fundaciones Comunitarias en México</h2>
          <p class="text-center">
            Formato de Evaluación de la Experiencia.
          </p>
        </template>
        <div>
          <form method="get" action="/" class="form-horizontal">

            <div class="row">
              <div class="col-sm-10">
                <p>
                  ¿Esta iniciativa te proporcionó guía y opciones para tratar tu salud mental y estrés para poder enfrentar mejor las situaciones laborales?
                </p>
                <radio label="1" v-model="radios.radio1">Si</radio>
                <radio label="2" v-model="radios.radio1">No</radio>
              </div>
            </div>
            <br>
            <div class="row">
              <div class="col-sm-10">
                <p>
                  Del 1 al 3 ¿Qué tanto consideras te fue de utilidad esta iniciativa?
                </p>
                <radio label="1" v-model="radios.radio2">1. Muy útil</radio>
                <radio label="2" v-model="radios.radio2">2. Útil</radio>
                <radio label="3" v-model="radios.radio2">3. Nada útil</radio>
              </div>
            </div>
            <br>
            <div class="row">
              <div class="col-sm-10">
                <p>
                  ¿Las opciones proporcionadas por DERIVA te sirvieron y fueron afines a lo que buscabas?
                </p>
                <radio label="1" v-model="radios.radio3">Si</radio>
                <radio label="2" v-model="radios.radio3">Momentáneamente</radio>
                <radio label="3" v-model="radios.radio3">No</radio>
              </div>
            </div>
            <br>
            <div class="row">
              <div class="col-sm-10">
                <p>
                  ¿Te interesaría volver a participar en una iniciativa similar?
                </p>
                <radio label="1" v-model="radios.radio4">Si</radio>
                <radio label="2" v-model="radios.radio4">No</radio>
              </div>
            </div>
            <br>
            <div class="row">
              <div class="col-sm-10">
                <p>
                  Comentarios u observaciones adicionales
                </p>
                <fg-input class="text-area" placeholder=""> </fg-input>
              </div>
            </div>
            <br>
            <div class="row">
              <div class="col-sm-10">
                <p>
                  ¿A cuál organización pertences?
                </p>
                <radio label="1" v-model="radios.radio6">Comunalia</radio>
                <radio label="2" v-model="radios.radio6">Comunalia (Morelos)</radio>
                <radio label="3" v-model="radios.radio6">Comunalia (Nuevo León)</radio>
                <radio label="4" v-model="radios.radio6">FC Cozumel</radio>
                <radio label="5" v-model="radios.radio6">Fundación Comunitaria Cozumel</radio>
                <radio label="6" v-model="radios.radio6">Fundación Comunitaria Frontera Norte</radio>
                <radio label="7" v-model="radios.radio6">Fundación Comunitaria Malinalco</radio>
                <radio label="8" v-model="radios.radio6">Fundación Comunitaria Oaxaca</radio>
                <radio label="9" v-model="radios.radio6">Fundación Comunitaria Puebla</radio>
                <radio label="10" v-model="radios.radio6">Fundación Comunitaria Punta de Mita</radio>
                <radio label="11" v-model="radios.radio6">Fundación Internacional de la Comunidad</radio>
                <radio label="12" v-model="radios.radio6">Fundación Merced Coahuila</radio>
                <radio label="13" v-model="radios.radio6">Fundación Merced Querétaro</radio>
              </div>
            </div>
            <br>
            <n-button
              slot="footer"
              type="primary"
              native-type="submit"
              round
              size="lg"
            >
              Enviar Respuestas
            </n-button>
          </form>
        </div>
      </card>
      <!-- end card -->
    </div>
  </div>
</template>
<script>
import { Radio } from "src/components/index";

export default {
  components: {
    Radio
  },
  data() {
    return {
      radios: {
        radio1: "1",
        radio2: "1",
        radio3: "1",
        radio4: "1",
        radio5: "1",
        radio6: "1",
        radio7: "1",
        radio8: "1",
        radio9: "1",
      },
      email: ""
    };
  },
  methods:{
    submit() {
      alert("Form has been submitted!");
    }
  }
};
</script>
<style></style>
