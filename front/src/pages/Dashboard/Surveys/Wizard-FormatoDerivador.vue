<template>
  <div>
    <div class="row d-flex justify-content-center">
      <div class="col-md-10 mr-auto ml-auto">
        <simple-wizard>
          <template slot="header">
            <h3 class="card-title">Formato Derivador</h3>
            <h3 class="description">
            </h3>
          </template>

          <!--<wizard-tab :before-change="() => validateStep('step1')">-->
          <wizard-tab>
            <template slot="label">
              <i class="now-ui-icons users_single-02"></i>
              Usuario
            </template>
            <first-step
              ref="step1"
            ></first-step>
           <!-- <first-step
              ref="step1"
              @on-validated="onStepValidated"
            ></first-step>-->
          </wizard-tab>

          <!--<wizard-tab :before-change="() => validateStep('step2')">-->
          <wizard-tab>
            <template slot="label">
              <i class="now-ui-icons files_paper"></i>
              Cuestionario
            </template>
            <!--<second-step
              ref="step2"
              @on-validated="onStepValidated"
            ></second-step>-->
            <second-step
              ref="step2"
            ></second-step>
          </wizard-tab>

          <!-- <wizard-tab :before-change="() => validateStep('step3')"> -->
          <wizard-tab>
            <template slot="label">
              <i class="now-ui-icons design-2_ruler-pencil"></i>
              Escala de Derivación Psinóptica
            </template>
            <!--<third-step ref="step3" @on-validated="wizardComplete"></third-step>-->
            <third-step ref="step3"></third-step>
          </wizard-tab>
        </simple-wizard>
      </div>
    </div>
  </div>
</template>
<script>
import FirstStep from "./FormatoDerivadorStep1.vue";
import SecondStep from "./FormatoDerivadorStep2.vue";
import ThirdStep from "./FormatoDerivadorStep3.vue";
import Swal from "sweetalert2";
import { SimpleWizard, WizardTab } from "src/components";

export default {
  data() {
    return {
      wizardModel: {}
    };
  },
  components: {
    FirstStep,
    SecondStep,
    ThirdStep,
    SimpleWizard,
    WizardTab
  },
  methods: {
   /*  validateStep(ref) {
      return this.$refs[ref].validate();
    },
   onStepValidated(validated, model) {
      this.wizardModel = { ...this.wizardModel, ...model };
    },*/
    wizardComplete() {
      Swal.fire({
        title: "Good job!",
        text: "You clicked the finish button!",
        type: "success",
        confirmButtonClass: "btn btn-success",
        buttonsStyling: false
      });
    }
  }
};
</script>
