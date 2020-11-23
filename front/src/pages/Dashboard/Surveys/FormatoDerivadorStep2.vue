<template>
<ValidationObserver v-slot="{ handleSubmit }">
    <form @submit.prevent="handleSubmit(submit)">
      <div class="row">
        <div class="col-lg-12 mr-auto">
          <div class="row">
              <div class="col-sm-12">
                <p>
                  ¿Para quién es la terapia?
                </p>
                <radio label="1" v-model="radios.radio1">Para mí</radio>
                <radio label="2" v-model="radios.radio1">Para alguien más</radio>
              </div>
            </div>
            <br>

            <div class="row">
              <div class="col-sm-12">
                <p>
                  ¿Cuánto estás dispuesto a invertir semanalmente en terapia?
                </p>
                <radio label="1" v-model="radios.radio2">$100 a $300</radio>
                <radio label="2" v-model="radios.radio2">$301 a $600</radio>
                <radio label="3" v-model="radios.radio2">$601 a $1000</radio>
                <radio label="4" v-model="radios.radio2">$1000 adelante</radio>
              </div>
            </div>
            <br>

            <div class="row">
              <div class="col-sm-12">
                <p>
                  ¿Cuánto tiempo estás dispuesto a invertir semanalmente en terapia?
                </p>
                <radio label="1" v-model="radios.radio3">1 hora</radio>
                <radio label="2" v-model="radios.radio3">2 horas</radio>
                <radio label="3" v-model="radios.radio3">3 horas en adelante</radio>
              </div>
            </div>
            <br>
            
            
            <ValidationProvider
              name="locationUser"
              rules="required"
              v-slot="{ passed, failed }"
            >
              <fg-input
                type="text"
                :error="failed ? 'Ubicación requerida' : null"
                :hasSuccess="passed"
                placeholder="¿En qué ciudad (colonia) o delegación vives tu o la persona que vaya a recibir terapia?"
                addon-left-icon="now-ui-icons location_pin"
                v-model="locationUser"
              >
              </fg-input>
            </ValidationProvider>

            <ValidationProvider
              name="location"
              rules="required"
              v-slot="{ passed, failed }"
            >
              <fg-input
                type="text"
                :error="failed ? 'Ubicación requerida' : null"
                :hasSuccess="passed"
                placeholder="¿En qué colonia o sector de la ciudad prefiere recibir terapia?"
                addon-left-icon="now-ui-icons location_pin"
                v-model="location"
              >
              </fg-input>
            </ValidationProvider>

            <div class="row">
              <div class="col-sm-12">
                <p>
                  ¿Cómo te transportas por la ciudad normalmente?
                </p>
                <radio label="1" v-model="radios.radio4">Bicicleta</radio>
                <radio label="2" v-model="radios.radio4">Auto</radio>
                <radio label="3" v-model="radios.radio4">Transporte público</radio>
                <radio label="4" v-model="radios.radio4">Caminando</radio>
                <radio label="5" v-model="radios.radio4">Taxi/Uber</radio>
              </div>
            </div>
            <br>

            <div class="row">
              <div class="col-sm-12">
                <p>
                  ¿Qué tipo de terapeuta prefieres?
                </p>
                <radio label="1" v-model="radios.radio5">Mujer</radio>
                <radio label="2" v-model="radios.radio5">Hombre</radio>
                <radio label="3" v-model="radios.radio5">No importa, cualquier de los dos</radio>
                <radio label="4" v-model="radios.radio5">No sé, no lo había pensado</radio>
              </div>
            </div>
            <br>

            <div class="row">
              <div class="col-sm-12">
                <p>
                  ¿Cuál es tu estado civil?
                </p>
                <radio label="1" v-model="radios.radio6">Soltero</radio>
                <radio label="2" v-model="radios.radio6">Casado(a)/Unión Libre</radio>
                <radio label="3" v-model="radios.radio6">Separado(a)/Divorciado(a)</radio>
                <radio label="4" v-model="radios.radio6">Viudo(a)</radio>
              </div>
            </div>
            <br>

            <div class="row">
              <div class="col-sm-12">
                <p>
                  ¿Con quién vives?
                </p>
                <radio label="1" v-model="radios.radio7">Independiente</radio>
                <radio label="2" v-model="radios.radio7">Con otras personas (amigos, compañeros)</radio>
                <radio label="3" v-model="radios.radio7">Con mis papás</radio>
                <radio label="4" v-model="radios.radio7">Con familia propia (hijos, cónyuge)</radio>
              </div>
            </div>
            <br>

            <div class="row">
              <div class="col-sm-12">
                <p>
                  ¿Tienes habitación propia?
                </p>
                <radio label="1" v-model="radios.radio8">Sí</radio>
                <radio label="2" v-model="radios.radio8">No</radio>
              </div>
            </div>
            <br>

            <div class="row">
              <div class="col-sm-12">
                <p>
                  ¿Estás en algún tratamiento médico, psiquiátrico o alternativo? Especifica cual y que duración
                </p>
                <radio label="1" v-model="radios.radio9">Sí</radio>
                <radio label="2" v-model="radios.radio9">No</radio>
              </div>
            </div>
            <br>

            <div class="row">
              <div class="col-sm-12">
                <p>
                  ¿Qué horario es más accesible para ti?
                </p>
                <radio label="1" v-model="radios.radio10">Matutino (8:00 a 12:00)</radio>
                <radio label="2" v-model="radios.radio10">Vespertino (13:00 a 18:00)</radio>
                <radio label="3" v-model="radios.radio10">Nocturno (19:00 a 21:00)</radio>
              </div>
            </div>
            <br>

            <ValidationProvider
              name="opinion"
              rules="required"
              v-slot="{ passed, failed }"
            >
              <fg-input
                type="text"
                :error="failed ? 'Requerido' : null"
                :hasSuccess="passed"
                placeholder="¿Qué es lo que te trae con nosotros?"
                addon-left-icon="now-ui-icons text_caps-small"
                v-model="opinion"
              >
              </fg-input>
            </ValidationProvider>

            <div class="row">
              <div class="col-sm-12">
                <p>
                  ¿Qué tan comprometido está para solucionar su problema?
                </p>
                <radio label="1" v-model="radios.radio11">Muy comprometido, se que lo voy a resolver</radio>
                <radio label="2" v-model="radios.radio11">Comprometido, tiene solución</radio>
                <radio label="3" v-model="radios.radio11">Depende de circunstancias ajenas a mi, me sobrepasa</radio>
                <radio label="4" v-model="radios.radio11">No creo que mi problema tenga solución</radio>
              </div>
            </div>
            <br>

            <div class="row">
              <div class="col-sm-12">
                <p>
                  ¿Presentó identificación de su institución?
                </p>
                <radio label="1" v-model="radios.radio12">Sí</radio>
                <radio label="2" v-model="radios.radio12">No</radio>
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
