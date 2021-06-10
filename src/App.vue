<template>
    <div>Hello All
        <table class="table table-striped">
          <thead>
            <tr>
              <th scope="col">Device</th>
              <th scope="col">RequestedDate</th>
              <th scope="col">id</th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="result in results">
              <td>{{ result.Device }}</td>
              <td>{{ result.RequestedDate }}</td>
              <td>{{ result.id }}</td>
            </tr>
          </tbody>
        </table>
    </div>
</template>


<script>
const url = "/api/getdevices";

const vm = new Vue({
        el: '#app',
        data: {
          results: []
        },
        mounted() {
          axios.get(url).then(response => {
            this.results = response.data
          })
        }
      });

</script> 
