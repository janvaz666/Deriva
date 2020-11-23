<template>
<ValidationObserver v-slot="{ handleSubmit }">
    <form @submit.prevent="handleSubmit(submit)">
      <div class="row">

        <div class="col-lg-12">
         <!-- <card class="card-signup" no-footer-line>
            <template slot="header">
              <h4 class="card-title text-center">Formato Derivador</h4>
               <h5 class="text-center">
                      Usuario
              </h5>
            </template> -->

             <div class="row">
              <div class="col-sm-1">
                <p>Individual</p>
              </div>
              <div class="col-sm-1">
                <radio label="1" v-model="radios.radio2">	Psicoeducación</radio>
              </div>
              <div class="col-sm-1">
                <radio label="2" v-model="radios.radio2">Personare</radio>
              </div>
              <div class="col-sm-1">
                <radio label="3" v-model="radios.radio2">Catarsis</radio>
              </div>
              <div class="col-sm-1">
                <radio label="4" v-model="radios.radio2">Socious</radio>
              </div>
              <div class="col-sm-1">
                <radio label="5" v-model="radios.radio2">Trasfondo</radio>
              </div>
              <div class="col-sm-1">
                <radio label="6" v-model="radios.radio2">Direccionar</radio>
              </div>
              <div class="col-sm-1">
                <radio label="7" v-model="radios.radio2">Focalizar</radio>
              </div>
              <div class="col-sm-1">
                <radio label="8" v-model="radios.radio2">Planeación</radio>
              </div>
              <div class="col-sm-1">
                <radio label="9" v-model="radios.radio2">Resolución</radio>
              </div>
              <div class="col-sm-1">
                <label>Cierre(Seriación)</label>
                <radio label="10" v-model="radios.radio2"></radio>
              </div>
            </div>

            <div class="row">
              <div class="col-sm-4">
                <p>	¿Si ya se aplicó el cuestionario, te proporcionaron protocolo, atención a casos y prevención?</p>
              </div>
              <div class="col-sm-2">
                <radio label="1" v-model="radios.radio2">Sí</radio>
              </div>
              <div class="col-sm-2">
                <radio label="2" v-model="radios.radio2">No</radio>
              </div>
              <div class="col-sm-2">
                <radio label="3" v-model="radios.radio2">No sé</radio>
              </div>
            </div>

            <ValidationProvider
              name="name"
              rules="required"
              v-slot="{ passed, failed }"
            >
              <fg-input
                type="text"
                :error="failed ? 'Nombre(s) requerido.' : null"
                :hasSuccess="passed"
                placeholder="Nombre(s)"
                addon-left-icon="now-ui-icons users_circle-08"
                v-model="name"
              >
              </fg-input>
            </ValidationProvider>

            <ValidationProvider
              name="primerApellido"
              rules="required"
              v-slot="{ passed, failed }"
            >
              <fg-input
                type="text"
                :error="failed ? 'Primer Apellido es requerido' : null"
                :hasSuccess="passed"
                placeholder="Primer Apellido..."
                addon-left-icon="now-ui-icons text_caps-small"
                v-model="primerApellido"
              >
              </fg-input>
            </ValidationProvider>
        </div>
      </div>
    </form>
  </ValidationObserver>
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
