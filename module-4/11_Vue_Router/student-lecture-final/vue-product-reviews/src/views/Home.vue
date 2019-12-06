<template>
    <div class="home">
        <product-review></product-review>
    </div>
</template>

<script>
    import ProductReview from '@/components/ProductReview.vue';

    export default {
        name: "home",
        components: {
            ProductReview
        }
    }
</script>

<style scoped>
    div.main {
        margin: 1rem 0;
    }
</style>
