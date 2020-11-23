<template>
<ValidationObserver v-slot="{ handleSubmit }">
    <form @submit.prevent="handleSubmit(submit)">
      <div class="row">

        <div class="col-lg-12 mr-auto">
         <!-- <card class="card-signup" no-footer-line>
            <template slot="header">
              <h4 class="card-title text-center">Formato Derivador</h4>
               <h5 class="text-center">
                      Usuario
              </h5>
            </template> -->

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


            <ValidationProvider
              name="segundoApellido"
              rules="required"
              v-slot="{ passed, failed }"
            >
              <fg-input
                type="text"
                :error="failed ? 'Segundo Apellido es requerido' : null"
                :hasSuccess="passed"
                placeholder="Segundo Apellido..."
                addon-left-icon="now-ui-icons text_caps-small"
                v-model="segundoApellido"
              >
              </fg-input>
            </ValidationProvider>

            <p>Sexo</p>
            <radio label="1" v-model="radios.radio1">Masculino</radio>
            <radio label="2" v-model="radios.radio1">Femenino</radio>
            <br>

            <ValidationProvider
                name="age"
                rules="required|numeric"
                v-slot="{ passed, failed }"
              >
                <fg-input
                  type="number"
                  :error="failed ? 'Edad es requerida.' : null"
                  :hasSuccess="passed"
                  placeholder="Edad"
                  addon-left-icon="now-ui-icons users_circle-08"
                  v-model="number"
                >
                </fg-input>
            </ValidationProvider>

            <ValidationProvider
                name="number"
                rules="required|numeric"
                v-slot="{ passed, failed }"
              >
                <fg-input
                  type="number"
                  :error="failed ? 'El número de teléfono es requerido.' : null"
                  :hasSuccess="passed"
                  placeholder="Número de teléfono"
                  addon-left-icon="now-ui-icons tech_mobile"
                  v-model="phoneNumber"
                >
                </fg-input>
            </ValidationProvider>

             <ValidationProvider
              name="email"
              rules="required|email"
              v-slot="{ passed, failed }"
            >
              <fg-input
                type="email"
                :error="failed ? 'El correo electrónico es requerido' : null"
                :hasSuccess="passed"
                placeholder="Correo electrónico..."
                addon-left-icon="now-ui-icons ui-1_email-85"
                v-model="email"
              >
              </fg-input>
            </ValidationProvider>

            <div class="row">
              <div class="col-sm-10">
                <p>
                  Viene referenciado de:
                </p>
                <radio label="1" v-model="radios.radio2">Comunalia</radio>
                <radio label="2" v-model="radios.radio2">Gentera</radio>
                <radio label="3" v-model="radios.radio2">LHxM</radio>
                <radio label="4" v-model="radios.radio2">Hospital ABC</radio>
                <radio label="5" v-model="radios.radio2">Fiscalía</radio>
                <radio label="6" v-model="radios.radio2">CAEM</radio>
                <radio label="7" v-model="radios.radio2">FECHAC</radio>
              </div>
            </div>
            <br>
            <div class="row">
              <div class="col-sm-10">
                <p>
                  Asistencia del usuario a consulta
                </p>
                <radio label="1" v-model="radios.radio3">Si se presentó</radio>
                <radio label="2" v-model="radios.radio3">No se presentó</radio>
              </div>
            </div>
            <br>
            <div class="row">
              <div class="col-sm-10">
                <p>
                  ¿Deseas que nos mantengamos en contacto para dar seguimiento a tu caso?
                </p>
                <radio label="1" v-model="radios.radio4">Si</radio>
                <radio label="2" v-model="radios.radio4">No</radio>
              </div>
            </div>
            <br>
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
