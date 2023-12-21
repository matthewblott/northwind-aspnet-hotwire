import { Controller } from '@hotwired/stimulus'

export default class extends Controller {
  static targets = ['the_input', 'the_submit', 'the_value']

  selected(event) {
    const { id, value } = event.detail;
    this.the_valueTarget.value = id 
    this.the_inputTarget.value = value;
  }

  query() {
    clearTimeout(this.timeout)
    this.timeout = setTimeout(() => {
      if (this.the_inputTarget.value.length > 1) {
        this.the_submitTarget.click()
      }
    }, 500)
  }
}
