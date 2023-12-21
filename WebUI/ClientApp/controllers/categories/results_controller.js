import { Controller } from '@hotwired/stimulus'

export default class extends Controller {
  static targets = ['the_list']

  select(event) {
    const id = event.currentTarget.querySelector('span').innerText
    const value = event.currentTarget.innerText
    this.dispatch('selected', { detail: { id, value} })
    this.the_listTarget.innerHTML = ''
  }
}
