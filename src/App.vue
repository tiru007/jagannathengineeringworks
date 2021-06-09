<template>
    <div>Hello {{ value }}</div>
    <div>
        <table class="table table-striped">
            <thead>
                <tr>
                    <th scope="col">Device</th>
                    <th scope="col">DeviceType</th>
                    <th scope="col">id</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="result in results">
                    <td>{{ result.deviceName }}</td>
                    <td>{{ result.deviceType }}</td>
                    <td>{{ result.deviceId }}</td>
                </tr>
            </tbody>
        </table>
    </div>
</template>

<script>
    export default {
        data() {
            return {
                results: [],
                errors: []
            }
        },

        // Fetches posts when the component is created.
        created() {
            axios.get(`/api/getdevices`)
                .then(response => {
                    // JSON responses are automatically parsed.
                    this.results = response.data
                })
                .catch(e => {
                    this.errors.push(e)
                })
        }
    };
</script>
