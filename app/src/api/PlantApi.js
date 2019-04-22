import axios from 'axios'

export default class {
    static async getPlants() {
        const result = await axios.get('/api/plant/GetPlants');
        return result.data;
    }
}