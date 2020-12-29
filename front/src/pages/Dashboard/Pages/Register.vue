<template>
  <ValidationObserver v-slot="{ handleSubmit }">
    <form @submit.prevent="handleSubmit(submit)">
      <div class="row">
        
        <div class="col-lg-5 ml-auto">
          <div class="picture">
            <img
              src="img/Logo Deriva_horizontal_slogan.png"
              alt="Thumbnail Image"
              class="rounded img-raised"
            />
          </div>
        </div>
        
        <div class="col-lg-4 mr-auto">
          <card class="card-signup text-center" no-footer-line>
            
            <ValidationProvider
              name="cedulaProfesional"
              rules="required"
              v-slot="{ passed, failed }"
            >
              <fg-input
                type="text"
                :error="failed ? 'La cédula Profesional es requerida' : null"
                :hasSuccess="passed"
                placeholder="Cédula Profesional..."
                addon-left-icon="now-ui-icons users_circle-08"
                v-model="item.cedulaProfesional"
              >
              </fg-input>
            </ValidationProvider>

            <ValidationProvider
              name="nombre"
              rules="required"
              v-slot="{ passed, failed }"
            >
              <fg-input
                type="text"
                :error="failed ? 'El nombre es requerido' : null"
                :hasSuccess="passed"
                placeholder="Nombre ..."
                addon-left-icon="now-ui-icons text_caps-small"
                v-model="item.nombre"
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
                :error="failed ? 'El Primer Apellido es requerido' : null"
                :hasSuccess="passed"
                placeholder="Primer Apellido ..."
                addon-left-icon="now-ui-icons text_caps-small"
                v-model="item.primerApellido"
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
                :error="failed ? 'El Segundo Apellido es requerido' : null"
                :hasSuccess="passed"
                placeholder="Segundo Apellido ..."
                addon-left-icon="now-ui-icons text_caps-small"
                v-model="item.segundoApellido"
              >
              </fg-input>
            </ValidationProvider>


            <ValidationProvider
              name="telefono"
              rules="required"
              v-slot="{ passed, failed }"
            >
              <fg-input
                type="text"
                :error="failed ? 'El Télefono es requerido' : null"
                :hasSuccess="passed"
                placeholder="Télefono ..."
                addon-left-icon="now-ui-icons text_caps-small"
                v-model="item.telefono"
              >
              </fg-input>
            </ValidationProvider>

            <ValidationProvider
              name="correo"
              rules="required|email"
              v-slot="{ passed, failed }"
            >
              <fg-input
                type="email"
                :error="failed ? 'El correo Eletronico es requerido' : null"
                :hasSuccess="passed"
                placeholder="Correo Electronico..."
                addon-left-icon="now-ui-icons ui-1_email-85"
                v-model="item.correo"
              >
              </fg-input>
            </ValidationProvider>

            <checkbox class="text-left" v-model="item.sactivo">
              Confidencialidad de datos.
            </checkbox>

            <n-button
              slot="footer"
              type="primary"
              native-type="submit"
              round
              size="lg"
            >
              Get Started
            </n-button>
          </card>
        </div>
      </div>
    </form>
  </ValidationObserver>
</template>
<script>
import { Checkbox } from "src/components";

import { extend } from "vee-validate";
import { required, email, confirmed } from "vee-validate/dist/rules";

extend("email", email);
extend("required", required);
extend("confirmed", confirmed);

export default {
  components: {
    Checkbox
  },
  data() {
    return {
      item: {
      correo: "",
      cedulaProfesional: "",
      nombre: "",
      primerApellido: "",
      segundoApellido: "",
      telefono: "",
      activo: false
      }
    };
  },
  methods: {
    async register() {
      let isValidForm = await this.$validator.validate();
      if (isValidForm) {
        await this.saveItem();
      }
      
    },
    async saveItem() {
      // this.payload.prospecto.fechaEnvio = this.getDatetime();
      // this.payload.prospecto.fechaAsignacion = this.getDatetime();
      await this.$http
        .post(route("Registro/AddRegistro"), this.item)
        .then(
          async response => {
            if (response.body.code === 200) {
              this.notifyMessage("success", this.$t("app.promps.save_success"));
              this.correctSave = true;
            } else {
              this.trubbleSave = true;
              this.notifyMessage("danger", this.$t("app.promps.error"));
            }
          },
          error => {
            this.trubbleSave = true;
            this.notifyMessage("danger", this.$t("app.promps.error"));
          }
        )
        .finally(() => {});
    },
    async submit() {
      await this.saveItem();
    }
  }
};
</script>
<style></style>
