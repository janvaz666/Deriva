<template>
  <div class="row">
    <div class="col-md-12">
      <card>
        <template slot="header">
          <h2 class="text-center">Riesgo Psicológico</h2>
          <p class="text-center">
            Con este breve cuestinario puedes medir tu riesgo de niveles alto de estrés, ansiedad y otros 
            factores psicológicos. Lee con atención las siguientes preguntas y responde con honestidad.
            Los resultados son anónimos.
          </p>
        </template>
        <div>
          <form method="get" action="/" class="form-horizontal">

            <div class="row">
              <div class="col-sm-10">
                <p>
                  ¿Has tenido dificultad para dormir en las últimas semanas?
                </p>
                <radio label="1" v-model="radios.radio1">Si</radio>
                <radio label="2" v-model="radios.radio1">No</radio>
              </div>
            </div>
            <br>
            <div class="row">
              <div class="col-sm-10">
                <p>
                  ¿Te has sentido triste, con pérdida del apetito, falto de interés o fatigado en las últimas semanas?
                </p>
                <radio label="1" v-model="radios.radio2">Si</radio>
                <radio label="2" v-model="radios.radio2">No</radio>
              </div>
            </div>
            <br>
            <div class="row">
              <div class="col-sm-10">
                <p>
                  ¿Has tenido pensamientos agresivos o conductas que afecten tu salud en las últimas semanas?
                </p>
                <radio label="1" v-model="radios.radio3">Si</radio>
                <radio label="2" v-model="radios.radio3">No</radio>
              </div>
            </div>
            <br>
            <div class="row">
              <div class="col-sm-10">
                <p>
                  ¿Te has sentido ansioso o estresado en los últimos meses, la mayor parte del tiempo?
                </p>
                <radio label="1" v-model="radios.radio4">Si</radio>
                <radio label="2" v-model="radios.radio4">No</radio>
              </div>
            </div>
            <br>
            <div class="row">
              <div class="col-sm-10">
                <p>
                  ¿Has experimentado cambios en tu estado de ánimo en los últimos días o semanas, muy motivado o muy deprimido súbitamente?
                </p>
                <radio label="1" v-model="radios.radio5">Si</radio>
                <radio label="2" v-model="radios.radio5">No</radio>
              </div>
            </div>
            <br>
            <div class="row">
              <div class="col-sm-10">
                <p>
                  ¿Has tenido pensamientos repetitivos o recurrentes sobre cualquier tema, que estén afectando tu ritmo de vida cotidiano?
                </p>
                <radio label="1" v-model="radios.radio6">Si</radio>
                <radio label="2" v-model="radios.radio6">No</radio>
              </div>
            </div>
            <br>
            <div class="row">
              <div class="col-sm-10">
                <p>
                  ¿Has experimentado algunos de estos síntomas por meses y no semanas?
                </p>
                <radio label="1" v-model="radios.radio7">Si</radio>
                <radio label="2" v-model="radios.radio7">No</radio>
              </div>
            </div>
            <br>
            <div class="row">
              <div class="col-sm-10">
                <p>
                  ¿Has sufrido la pérdida de algún ser querido en los últimos meses?
                </p>
                <radio label="1" v-model="radios.radio8">Si</radio>
                <radio label="2" v-model="radios.radio8">No</radio>
              </div>
            </div>
            <br>
            <div class="row">
              <div class="col-sm-10">
                <p>
                  ¿Hay algún aspecto de tu vida que quieras modificar pero no sabes cómo?
                </p>
                <radio label="1" v-model="radios.radio9">Si</radio>
                <radio label="2" v-model="radios.radio9">No</radio>
              </div>
            </div>
            <br>
            <div class="row">
              <div class="col-sm-10">
                <p>
                  Ingresa tu correo electrónico
                </p>
                <fg-input
                type="email"
                :error="failed ? 'El correo electrónico es requerido' : null"
                :hasSuccess="passed"
                placeholder="Correo electrónico..."
                addon-left-icon="now-ui-icons ui-1_email-85"
                v-model="email"
              >
              </fg-input>
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
