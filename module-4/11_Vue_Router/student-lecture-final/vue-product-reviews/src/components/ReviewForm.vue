<template>
    <div class="review-form">
        <a href="#" v-on:click.prevent="showForm = true" v-if="showForm === false">Show Form</a>

        <form v-if="showForm === true" v-on:submit.prevent="addNewReview">
            <div class="form-element">
                <label for="reviewer">Name:</label><input id="reviewer" type="text" v-model="review.reviewer" />
            </div>
            <div class="form-element">
                <label for="title">Title:</label> <input id="title" type="text" v-model="review.title" />
            </div>
            <div class="form-element">
                <label for="rating">Rating:</label> <select id="rating" v-model.number="review.rating">
                    <option value="1">1 Star</option>
                    <option value="2">2 Stars</option>
                    <option value="3">3 Stars</option>
                    <option value="4">4 Stars</option>
                    <option value="5">5 Stars</option>
                </select>
            </div>
            <div class="form-element">
                <label for="review">Review</label>
                <textarea id="review" v-model="review.review"></textarea>
            </div>
            <button v-bind:disabled="!isFormValid">Submit</button>
            <button v-on:click.prevent="resetForm" type="cancel">Cancel</button>
        </form>
    </div>
</template>

<script>
export default {
    name: 'review-form',
    data() {
        return {
            showForm: false,
            review: {}
        }
    },
    computed: {
        isFormValid() {
            // return true if all of the values in review are truthy
            return this.review.reviewer && this.review.title && 
                    this.review.rating && this.review.review;
        },
    },
    methods: {
        addNewReview() {
            this.$emit('new-review', this.review);
            this.resetForm();
        },
        resetForm() {
            this.showForm = false;
            this.review = {};
        },
    }
}
</script>

<style scoped>
    .form-element {
        display: flex;
        justify-content: flex-end;
        padding: .5em;
    }

    .form-element label {
        padding: .5em 1em .5em 0;
        flex: 1;
    }

    .form-element input, div.main .form-element select, div.main .form-element textarea {
        flex: 2;
    }

    .form-element textarea {
        height: 10rem;
    }

    .form-element input, div.main .form-element button {
        padding: 0.5em;
    }

    .form-element button {
        background: gray;
        color: white;
        border: 0;
    }
</style>