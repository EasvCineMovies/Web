
import http from 'k6/http'

export const options = {
    threshold: {
        http_req_failed: ['rate<0.01'],
        http_req_duration: ['p(95)<200']
    },
    duration: '5s',
    vus: 50
}

export default function () {
    http.get('https://easvcinemovies.azurewebsites.net/')
}