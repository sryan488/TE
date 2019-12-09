<template>
    <div class="user-profile">
        <h1>User Detail</h1>
        <pre>
            {{ user }}
        </pre>
    </div>
</template>

<script>
    import userService from '@/service/UserService';

    export default {
        name: 'user-detail',
        data() {
            return {
                user: null,
            }
        },
        methods: {
            getUser(id) {
                userService.get(id).then( (user) => { this.user = user; } );
            }
        }, 
        created() {
            this.getUser(this.$route.params.id);
        }
    }
</script>

<style>

</style>