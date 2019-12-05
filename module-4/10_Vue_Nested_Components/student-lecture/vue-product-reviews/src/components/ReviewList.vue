<template>
    <div class="review-list">
        <div class="review" v-for="review in filteredReviews" v-bind:key="review.id">
            <h4>{{ review.reviewer }}</h4>
            <div class="rating">
                <img src="../assets/star.png" v-bind:title="review.rating + ' Star Review'" class="ratingStar" v-for="n in review.rating" v-bind:key="n" />
            </div>
            <h3>{{ review.title }}</h3>

            <p>{{ review.review }}</p>
        </div>
    </div>
</template>

<script>
export default {
    name: 'review-list',
    props: {
        reviews: Array,
        filter: Number
    },
    computed: {
        filteredReviews() {
            return this.reviews.filter( (review) => {
                return this.filter === 0 ||
                        review.rating === this.filter;
            });        
        },
    }
}
</script>

<style scoped>
    div.review {
        border: 1px black solid;
        border-radius: 6px;
        padding: 1rem;
        margin: 10px;
    }

    div.review div.rating {
        height: 2rem;
        display: inline-block;
        vertical-align: top;
        margin: 0 0.5rem;
    }

    div.review div.rating img {
        height: 100%;
    }

    div.review p {
        margin: 20px;
    }
</style>