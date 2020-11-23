<template>
<ValidationObserver v-slot="{ handleSubmit }">
    <form @submit.prevent="handleSubmit(submit)">
      <div class="row">

        <div class="col-lg-12 mr-auto">
          <card class="card-signup text-center" no-footer-line>
            <template slot="header">
              <h4 class="card-title">Cuestionario Diagnóstico para Empresas</h4>

              <p slot="content">
                Datos básicos para generar una propuesta de cumplimiento y contención de factores de riesgo psicosocial en las organizaciones.
              </p>
            </template>

            <ValidationProvider
              name="nombres"
              rules="required"
              v-slot="{ passed, failed }"
            >
              <fg-input
                type="text"
                :error="failed ? 'Nombre(s) son requeridos' : null"
                :hasSuccess="passed"
                placeholder="Nombre(s)..."
                addon-left-icon="now-ui-icons users_circle-08"
                v-model="nombres"
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
                  v-model="number"
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

            <ValidationProvider
              name="compania"
              rules="required"
              v-slot="{ passed, failed }"
            >
              <fg-input
                type="text"
                :error="failed ? 'Nombre de la compañía es requerido' : null"
                :hasSuccess="passed"
                placeholder="Nombre de la compañía..."
                addon-left-icon="now-ui-icons text_caps-small"
                v-model="companieName"
              >
              </fg-input>
            </ValidationProvider>

            <ValidationProvider
              name="puesto"
              rules="required"
              v-slot="{ passed, failed }"
            >
              <fg-input
                type="text"
                :error="failed ? 'Puesto en la organización es requerido' : null"
                :hasSuccess="passed"
                placeholder="Puesto en la organización..."
                addon-left-icon="now-ui-icons text_caps-small"
                v-model="companieName"
              >
              </fg-input>
            </ValidationProvider>

             <ValidationProvider
                name="numberEmployes"
                rules="required|numeric"
                v-slot="{ passed, failed }"
              >
                <fg-input
                  type="number"
                  :error="failed ? 'Número de empleados es requerido.' : null"
                  :hasSuccess="passed"
                  placeholder="Número de empleados"
                  addon-left-icon="now-ui-icons business_badge"
                  v-model="number"
                >
                </fg-input>
            </ValidationProvider>
            <br>
            <div class="row">
              <div class="col-sm-4">
                <p>¿Ya se aplicó el cuestionario de la NOM-35?</p>
              </div>
              <div class="col-sm-2">
                <radio label="1" v-model="radios.radio1">Sí</radio>
              </div>
              <div class="col-sm-2">
                <radio label="2" v-model="radios.radio1">No</radio>
              </div>
              <div class="col-sm-2">
                <radio label="3" v-model="radios.radio1">No sé</radio>
              </div>
            </div>

            <div class="row">
              <div class="col-sm-4">
                <p>¿Ya se atendieron los casos positivos de ATS (Acontecimiento traumático severo)?</p>
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

            <n-button
              slot="footer"
              type="primary"
              native-type="submit"
              round
              size="lg"
            >
              Enviar respuestas
            </n-button>
          </card>
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
